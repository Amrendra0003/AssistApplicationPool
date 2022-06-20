import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Role } from '../auth/permission';
@Injectable({
    providedIn: "root"
})
export class AuthService {
    constructor(private http: HttpClient) { }
    AuthToken: any;
    UserRole: Role | undefined;
    get isLoggedIn(): boolean {
        try {
            this.AuthToken = sessionStorage.getItem('token');
            if (this.AuthToken != null && this.AuthToken != undefined && this.AuthToken != "")
                return true;
            else return false;
        }
        catch (err) {
            return false;
        }
    }
    get userPermissions() {
        let userPermissionData = sessionStorage.getItem('permissions');
        if (userPermissionData == null && userPermissionData == undefined && userPermissionData == "")
            return ['UnAuthorised'];
        let userPermission = (JSON.parse(userPermissionData!));
        return userPermission;
    }
    checkIfUserHasPermission(permissionInfo: string) {
        let userPermissions = this.userPermissions;
        var checkIfPermissionsExists = userPermissions?.find((t: any) => t == permissionInfo);

        if (checkIfPermissionsExists)
            return true;
        else
            return false;
    }
    IsSessionActive() {
        return true;
    }
    keepSessionAlive() {
    }
    logout() {
    }
    httpgetRequest(url: string) {
        return this.http.get(url);
    }
}
