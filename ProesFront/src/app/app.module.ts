import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { MenuComponent } from './menu/menu.component';
import { AppRoutingModule } from './app-routing.module';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginPageComponent } from './login/login-page/login-page.component';
import { FormsModule } from '@angular/forms';
import { AlertModule, AlertConfig } from 'ngx-bootstrap/alert';
import { JwtModule } from '@auth0/angular-jwt';
import { UserPageComponent } from './login/user-page/user-page.component';
import { UserDataService } from './shared/services/user-data.service';
import { LoginDataService } from './shared/services/login-data.service';
import { AdminComponent } from './admin/admin.component';

export function tokenGetter() {
  return localStorage.getItem("token");
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MenuComponent,
    NotFoundComponent,
    LoginPageComponent,
    UserPageComponent,
    AdminComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    AlertModule,
    CollapseModule.forRoot()
  ],
  providers: [AlertConfig, UserDataService, LoginDataService],
  bootstrap: [AppComponent]
})
export class AppModule {

}
