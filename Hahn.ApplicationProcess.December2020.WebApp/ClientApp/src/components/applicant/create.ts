import {autoinject, computedFrom} from 'aurelia-framework';
import {I18N} from 'aurelia-i18n';
import {ValidationRules, ValidationControllerFactory, ValidationController, validateTrigger, Validator} from 'aurelia-validation';
import { BootstrapFormRenderer } from 'common/util/bootstrap-form-renderer';
import { DialogService } from 'aurelia-dialog';
import {Applicant} from '../../common/models/applicant-model';
import {ApplicantService} from '../../common/services/applicant-service';
import {Router} from 'aurelia-router';
import { Prompt } from 'components/modals/prompt';
import * as toastr from 'toastr';
import { } from 'notifyjs-browser';
//import { Prompt } from 'components/modals/promt';


@autoinject
export class Create {
  //router: Router;
  applicant: Applicant = new Applicant();
  controller: ValidationController;
  enableBtn = false;

  constructor(private _applicantService: ApplicantService, validationFactory: ValidationControllerFactory, private _router: Router, private _dialogService: DialogService, private _i18N:I18N) {
    this.controller = validationFactory.createForCurrentScope();
    this.controller.validateTrigger = validateTrigger.changeOrBlur;
    
    
  }
  

  async setLocale(locale){
    var res = await this._i18N.setLocale(locale);
    
    console.log(res);
  }
 
  async submit() :Promise<void>{
    var result = await this._applicantService.save(this.applicant);
    if (result == "Success") {
      this._router.navigateToRoute('success')
    } else if(result == "NotFound"){
      this.showModal("Invalid CountryOfOrigin");
    }else if(result == "BadRequest"){
      this.showModal("Invalid Input");
    }else {
      this.showModal("system error");
    }

  } 

  reset(){
    this.applicant = null;
  }
  
  showModal(message){
    this._dialogService.open({ viewModel: Prompt, model: message, lock: false }).whenClosed(response => {
      if (!response.wasCancelled) {
        
      } else {
      }
    });
  }
  
  activate(){
    if(this.applicant){
      ValidationRules
      .ensure((p: Applicant) => p.Name).required().minLength(5)
      .ensure((p: Applicant) => p.EmailAddress).required().email()
      .ensure((p: Applicant) => p.Age).required().range(20,60)
      .ensure((p: Applicant) => p.FamilyName).required().minLength(5)
      .ensure((p: Applicant) => p.Address).required().minLength(10)
      .ensure((p: Applicant) => p.CountryOfOrigin).required()
      .on(this.applicant);
      this.controller.addRenderer(new BootstrapFormRenderer());
    }
  }

  deactivate(){
    this.controller.reset();
  }


}
