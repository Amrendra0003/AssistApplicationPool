import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { NgxPermissionsService } from 'ngx-permissions';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router, private permissionsService: NgxPermissionsService,) {}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if (Object.keys(this.permissionsService.getPermissions()).length <= 0 && this.authService.userPermissions)
      this.permissionsService.loadPermissions(this.authService.userPermissions);
    let userPermissions = this.authService.userPermissions;
    if (userPermissions && next.data.permissions) {
      var isUserPermissionsExists = userPermissions.find((t: any) => t == next.data.permissions.only);
      // check if route is restricted by permission
      if (!isUserPermissionsExists) { // permission not authorised so redirect to home page
        this.router.navigate(['pagenotfound']);
        return false;
      }
      // authorised so return true
      return true;
    }
    return this.checkLoggedIn(state.url);
  }
  checkLoggedIn(url: string) {
    if (this.authService.isLoggedIn)
      return true;
    else {
      this.router.navigate(['login']);
      return false;
    }
  }
}
