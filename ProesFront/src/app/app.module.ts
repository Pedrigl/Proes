import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {CollapseModule} from 'ngx-bootstrap/collapse'; 
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { MenuComponent } from './menu/menu.component';
import { AppRoutingModule } from './app-routing.module';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import {HttpClientModule} from '@angular/common/http'; 
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MenuComponent,
    NotFoundComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CollapseModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
title = 'Proes';
}
