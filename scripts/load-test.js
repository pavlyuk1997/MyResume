function loadCode() {
    fetch('automation/SharpAutomation/Tests/SeleniumDemoTest.cs')
      .then(response => response.text())
      .then(code => {
        const codeBlock = document.getElementById('code-block');
        codeBlock.textContent = code;
        Prism.highlightElement(codeBlock); // highlight using Prism.js
      })
      .catch(error => {
        console.error('Error loading code:', error);
      });
  }
  
  window.onload = loadCode;