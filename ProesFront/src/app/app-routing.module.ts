import { Injectable, NgModule } from '@angular/core';
import { RouterModule, Routes, UrlSerializer } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { LoginPageComponent } from './login/login-page/login-page.component';
import { AuthGuard } from './shared/services/auth-guard/auth.guard';
import { UserPageComponent } from './login/user-page/user-page.component';

// Create a routes Array
const routes: Routes = [
  { path: 'home', component: HomeComponent, canActivate:[AuthGuard] },
  { path: '', redirectTo: '/home', pathMatch: 'full'},
  { path: 'login', component: LoginPageComponent },
  { path: 'user', component: UserPageComponent, canActivate: [AuthGuard] },
  { path: 'profile', redirectTo: '/user', pathMatch: 'full'},
  { path: '404', component: NotFoundComponent },
  { path: '**', redirectTo: '/404', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthGuard]
})
export class AppRoutingModule { }
