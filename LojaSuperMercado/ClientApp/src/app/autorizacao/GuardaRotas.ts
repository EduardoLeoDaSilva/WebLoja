import { Injectable } from '@angular/core'
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router'


@Injectable({
  providedIn: "root"
})
export class GuardaRotas implements CanActivate {


  constructor(private router: Router) {

  }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean  {


      let isAutenticado = sessionStorage.getItem("userEmail");

      if (isAutenticado != '' || isAutenticado != null || isAutenticado != undefined) {
        return true;
      } else {
        this.router.navigate(['/login'], { queryParams: { returnURL: state.url } });
        return false;
      }

    }
    

}
