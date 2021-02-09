import {autoinject} from 'aurelia-framework';
import axios, { AxiosInstance, AxiosStatic } from 'axios';
import {HttpClient} from 'aurelia-fetch-client';
import {Applicant} from '../models/applicant-model'

@autoinject
export class ApplicantService {
  
  constructor(private _httpClient: HttpClient){
    
    _httpClient.configure( config => {
      config.useStandardConfiguration()
      .withBaseUrl('http://localhost:5000/api/')
      .withDefaults({
        headers: {
          'content-type': 'application/json',
          'Accept': 'application/json'
        }
      });
      
    });


  }
  

  async save(applicant:Applicant): Promise<string>  {
    try {

      const response = await this._httpClient.post('applicant', JSON.stringify(applicant));
      if (response.status == 201) {
        return "Success";
      }
      //const data = await response.json();
      if (response.status == 404) {
        return "NotFound";
      }

      if (response.status == 400) {
        return "BadRequest";
      }
      return 'Error';
    } catch (error) {
      console.log(error);
      return "Error";
    }
  
  }

  async getAll():Promise<Applicant[]>{
    try {
      const response = await this._httpClient.get('applicant');
      console.log(response);
    const applicants: Promise<Applicant[]> = await response.json();
    console.log(applicants);
    return applicants;
    } catch (error) {
      console.log(error)
    }
    
  }

  /* all():Promise<IApplicant[]>{
    this._httpClient.get
  } */
}
