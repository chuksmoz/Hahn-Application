import { RenderInstruction, ValidateResult,  } from "aurelia-validation";

export class BootstrapFormRenderer {
  isValid = true;
  
  render(instruction: RenderInstruction) {
    //console.log(instruction.unrender)
    for (let { result, elements } of instruction.unrender) {
      console.log(result.valid);
      for (let element of elements) {
        this.remove(element, result);
      }
    }

    for (let { result, elements } of instruction.render) {
      for (let element of elements) {
        this.add(element, result);
      }
    }
    //console.log(this.isValid);
  }

  add(element: Element, result: ValidateResult) {
    ////console.log(`${result.valid}  ADD`);
    this.isValid = this.isValid || result.valid;
    const formGroup = element.closest('.info');
    if (!formGroup) {
      return;
    }

    const formControl = element.closest('.form-control');
    if(!formControl) return;


    if (result.valid) {
      
      if (!formControl.classList.contains('is-invalid')) {
        formControl.classList.add('is-valid');
      }
      
    } else {
      // add the has-error class to the enclosing form-group div
      formControl.classList.remove('is-valid');
      formControl.classList.add('is-invalid');

      // add help-block
      const message = document.createElement('div');
      message.className = 'help-block invalid-feedback';
      message.textContent = result.message;
      message.id = `invalid-feedback-${result.id}`;
      formGroup.appendChild(message);
    }
    //const button = element.
    //console.log(element);
  }

  remove(element: Element, result: ValidateResult) {
    //console.log(`${result.valid}  REMOVE`);
    this.isValid = this.isValid || result.valid;
    const formGroup = element.closest('.info');
    if (!formGroup) {
      return;
    }

    const formControl = element.closest('.form-control');
    if(!formControl) return;

    if (result.valid) {
      if (formControl.classList.contains('is-valid')) {
        formControl.classList.remove('is-valid');
      }
      this.isValid = this.isValid && result.valid;
    } else {
      // remove help-block
      const message = formGroup.querySelector(`#invalid-feedback-${result.id}`);
      if (message) {
        formGroup.removeChild(message);

        // remove the has-error class from the enclosing form-group div
        if (formGroup.querySelectorAll('.help-block').length === 0) {
          formControl.classList.remove('is-invalid');
        }
      }
    }
  }
}
