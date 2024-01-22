import { ChangeDetectorRef, Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { AuthGuard } from '../shared/services/auth-guard/auth.guard';
import { AuthService } from '../shared/services/auth-guard/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit{
  isCollapsed: boolean = false;
  isVisible: boolean = false;
  showList: boolean = false;
  showNotifications: boolean = false;

  @ViewChild('listGroup') 
  listGroup!: ElementRef;

  @HostListener('document:click', ['$event'])
clickout(event: any) {
  if (this.isVisible && !event.target.closest('.list-group')) {
    if (this.listGroup && this.listGroup.nativeElement) {
      const rect = this.listGroup.nativeElement.getBoundingClientRect();
      const isClickedInside = (
        rect.top <= event.clientY &&
        rect.bottom >= event.clientY &&
        rect.left <= event.clientX &&
        rect.right >= event.clientX
      );

      if (!isClickedInside) {
        this.showList = false;
        this.showNotifications = false;
      }
    }
  }
}

  logOut() {
    this.authService.logOut();
    this.isVisible = false;
    this.router.navigateByUrl('/login');
  }

  stopClickPropagation(event: any) {
    event.stopPropagation();
  }
  constructor(private authService : AuthService, private router : Router) { }

  ngOnInit(): void {
    this.authService.authStatus$.subscribe({
        next: res => {
            this.isVisible = res;
        },
        error: err => {
            console.log(err);
        }
    });
  }

}
