import {autoinject} from 'aurelia-framework';
import {DialogController} from 'aurelia-dialog';
  
  @autoinject
  export class Prompt {
    //public controller: DialogController;
    message:string;
    constructor(private _controller: DialogController){
      //this.controller = _controller;
    }

    activate(message){
      this.message = message;
    }
  }
  
