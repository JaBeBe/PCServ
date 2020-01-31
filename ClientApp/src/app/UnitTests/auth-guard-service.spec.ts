import { TestBed, async, inject } from '@angular/core/testing';

import { AuthGuardServiceGuard } from '../login/auth-guard-service';

class MockRouter {
  navigate() { }
}

describe('AuthGuard', () => {
  describe('canActivate', () => {
    let authGuard: AuthGuardServiceGuard;
    let authService;
    let router ;

    it('should return true for a logged in user', () => {

      //sample with response from "server" with user login status
      authService = { isLoggedIn: () => true };
      router = new MockRouter();
      authGuard = new AuthGuardServiceGuard(authService, router);

      expect(authGuard.canActivate()).toEqual(true);
    });

    it('should return false for a logged out user', () => {

      //mock with response from "server" with user login status
      authService = { isLoggedIn: () => false };
      router = new MockRouter();
      authGuard = new AuthGuardServiceGuard(authService, router);

      expect(authGuard.canActivate()).toEqual(false);
    });

    it('should navigate to home for a logged out user', () => {

      //mock with response from "server" with user login status
      authService = { isLoggedIn: () => false };
      router = new MockRouter();
      authGuard = new AuthGuardServiceGuard(authService, router);
      spyOn(router, 'navigate');

      expect(authGuard.canActivate()).toEqual(false);
      expect(router.navigate).toHaveBeenCalledWith(['/']);
    });



  });
});