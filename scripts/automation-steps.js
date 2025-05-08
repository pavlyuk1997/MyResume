const steps = [
    {
      time: 0,
      code: 'NavigateByUrl() // Open dou.ua'
    },
    {
      time: 2.5,
      code: 'Search(query) // Enter and submit "Automation"'
    },
    {
      time: 4.5,
      code: 'GetSearchInputText(out string searchInputText)'
    },
    {
      time: 6,
      code: 'GetResultsCount(out int resultsCount)'
    },
    {
      time: 7.5,
      code: 'TapFirstResult()'
    },
    {
      time: 9.5,
      code: 'GetBodyText(out string vacancyBodyText)'
    }
  ];
  
  const video = document.getElementById('videoPlayer');
  const codeBlock = document.getElementById('codeBlock');
  let currentStep = 0;
  
  function showStep(index) {
    const step = steps[index];
    if (!step) return;
    codeBlock.textContent = step.code;
    Prism.highlightElement(codeBlock);
    video.currentTime = step.time;
    video.play();
  }
  
  function nextStep() {
    currentStep++;
    if (currentStep >= steps.length) currentStep = 0;
    showStep(currentStep);
  }
  
  document.addEventListener('DOMContentLoaded', () => {
    showStep(currentStep);
  });
  