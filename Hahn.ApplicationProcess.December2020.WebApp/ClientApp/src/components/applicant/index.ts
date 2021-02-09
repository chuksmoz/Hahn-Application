import { DialogService } from 'aurelia-dialog';
import {autoinject} from 'aurelia-framework';
import { Applicant } from "common/models/applicant-model";
import { ApplicantService } from 'common/services/applicant-service';

@autoinject
export class Index {
  applicants: Applicant[] = [];

  constructor(private _applicantService: ApplicantService, private _dialogService: DialogService) {
  }

  async attached(): Promise<void>{
    this.applicants = await this._applicantService.getAll();
  }
}
