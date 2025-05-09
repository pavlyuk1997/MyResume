const languageSelect = document.getElementById('languageSelect');
const frameworkSelect = document.getElementById('frameworkSelect');
const codeBlock = document.getElementById('codeBlock');
const videoPlayer = document.getElementById('videoPlayer');
const stepLabel = document.getElementById('stepLabel');
const frameworksByLanguage = {
  csharp: ["Selenium", "Playwright", "Atata"],
  js: ["Playwright", "WebDriverIO", "Cypress"]
};


let steps = [];
let currentStep = 0;
let originalCode = '';
let isSeeking = false;

function escapeHtml(text) {
  return text
    .replace(/&/g, "&amp;")
    .replace(/</g, "&lt;")
    .replace(/>/g, "&gt;");
}

function updateFrameworkOptions() {
  const selectedLang = languageSelect.value;
  const frameworks = frameworksByLanguage[selectedLang] || [];

  // Clear previous options
  frameworkSelect.innerHTML = '';

  frameworks.forEach(fw => {
    const opt = document.createElement('option');
    opt.value = fw.toLowerCase(); // matches your file naming convention
    opt.textContent = fw;
    frameworkSelect.appendChild(opt);
  });
}

function highlightLinesPrismReady(code, highlightLines = []) {
  const lang = languageSelect.value === 'js' ? 'javascript' : 'csharp';
  const grammar = Prism.languages[lang];
  const highlightedHtml = Prism.highlight(code, grammar, lang);

  const htmlLines = highlightedHtml.split('\n');

  return htmlLines.map((line, index) => {
    const lineNumber = index + 1;
    const isActive = highlightLines.includes(lineNumber);
    const cls = isActive ? 'code-line highlight' : 'code-line';
    return `<div class="${cls}">${line}</div>`;
  }).join('');
}

function showStep(index) {
  const step = steps[index];
  if (!step) return;

  const linesToHighlight = Array.isArray(step.line) ? step.line : [step.line];
  codeBlock.innerHTML = highlightLinesPrismReady(originalCode, linesToHighlight);

  // Label update
  stepLabel.textContent = `Крок ${index + 1} з ${steps.length} — ${step.label || '...'}`;
}

function nextStep() {
    currentStep++;
    if (currentStep >= steps.length) currentStep = 0;
  
    videoPlayer.currentTime = steps[currentStep].time;
    showStep(currentStep);
  
    // ✅ Only pause if user manually clicked Next
    videoPlayer.pause();
  }

  function updateContent() {
    const lang = languageSelect.value;
    const fw = frameworkSelect.value;
  
    const ext = lang === 'js' ? 'js' : 'cs';
    const codeFile = `code/${lang}/${fw}.${ext}`;
    const videoFile = `videos/${lang}-${fw}.mp4`;
    const stepFile = `../steps/${lang}-${fw}.js`;
  
    // Load full code FIRST
    fetch(codeFile)
      .then(res => res.text())
      .then(code => {
        originalCode = code;
        codeBlock.className = `language-${lang === 'js' ? 'javascript' : 'csharp'}`;
  
        // THEN load steps
        return import(stepFile);
      })
      .then(module => {
        steps = module.steps;
        currentStep = 0;
  
        videoPlayer.src = videoFile;
        videoPlayer.load();
        videoPlayer.currentTime = steps[currentStep].time;
  
        // Finally: show initial code highlight
        showStep(currentStep);
  
        // Optional: autoplay
        // videoPlayer.play();
      })
      .catch(err => console.error('Failed to load code or step file:', err));
  }
  
videoPlayer.addEventListener('timeupdate', () => {
  if (isSeeking) return; // skip update while we jump

  const currentTime = videoPlayer.currentTime;

  const matchingStep = steps
    .slice()
    .reverse()
    .find(step => currentTime >= step.time);

  const newIndex = steps.indexOf(matchingStep);

  if (newIndex !== -1 && newIndex !== currentStep) {
    currentStep = newIndex;
    showStep(currentStep);
  }
});

videoPlayer.addEventListener('seeked', () => {
  isSeeking = false;
});

document.addEventListener('DOMContentLoaded', () => {
  if (languageSelect && frameworkSelect) {
    languageSelect.addEventListener('change', updateContent);
    frameworkSelect.addEventListener('change', updateContent);
    updateFrameworkOptions();
    updateContent();
  }
});

languageSelect.addEventListener('change', () => {
  updateFrameworkOptions();
  updateContent(); // re-triggers loading code/video/etc
});
