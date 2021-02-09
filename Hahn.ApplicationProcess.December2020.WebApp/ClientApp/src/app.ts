import {PLATFORM} from 'aurelia-pal';
import {Router, RouterConfiguration} from 'aurelia-router';


export class App {
  public router: Router;

  public configureRouter(config: RouterConfiguration, router: Router): Promise<void> | PromiseLike<void> | void{
    config.title = 'Hahn Application';
    config.map([
      {
        route: ['', 'index'],
        name: 'index',
        moduleId: PLATFORM.moduleName('./components/applicant/index'),
        nav: true,
        title: 'Applicants'
      },
      {
        route: '/create',
        name: 'create',
        moduleId: PLATFORM.moduleName('./components/applicant/create'),
        nav: true,
        title: 'Create Applicant'
      },
      {
        route: '/success',
        name: 'success',
        moduleId: PLATFORM.moduleName('./components/applicant/success'),
        nav: true,
        title: 'success Message'
      }
    ]);
    config.mapUnknownRoutes('./components/applicant/create');
    this.router = router;
  }
  
}
