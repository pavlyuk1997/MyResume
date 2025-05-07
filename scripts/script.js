const steps = ['step1.png', 'step2.png', 'step3.png'];
let index = 0;

function nextStep() {
  index = (index + 1) % steps.length;
  document.getElementById('screenshot').src = 'images/' + steps[index];
}