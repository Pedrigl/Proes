import { Component, OnInit } from '@angular/core';
import {AuthGuard} from '../shared/services/auth-guard/auth.guard'; 
@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit{
  isCollapsed: boolean = false;
  isHidden: boolean = false;
  constructor(private authGuard : AuthGuard) { }

  ngOnInit(): void {
    this.isHidden = this.authGuard.isAuthenticated;
  }

}
