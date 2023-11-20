import { Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import {AuthGuard} from '../shared/services/auth-guard/auth.guard'; 
@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit{
  isCollapsed: boolean = false;
  isVisible: boolean = false;
  showList: boolean = false;
  items: string[] = ["Profile", "Settings", "Sign Out"]
  @ViewChild('listGroup') listGroup!: ElementRef;

  @HostListener('document:click', ['$event'])
  clickout(event: any) {
    
    if (this.isVisible && !event.target.closest('.list-group')) {
      const rect = this.listGroup.nativeElement.getBoundingClientRect();
      const isClickedInside = (
        rect.top <= event.clientY &&
        rect.bottom >= event.clientY &&
        rect.left <= event.clientX &&
        rect.right >= event.clientX
      );

      if (!isClickedInside) {
        this.showList = false;
      }
    }
  }

  stopClickPropagation(event: any) {
    event.stopPropagation();
  }
  constructor(private authGuard : AuthGuard) { }

  ngOnInit(): void {
    this.isVisible = this.authGuard.isAuthenticated;
  }

}
