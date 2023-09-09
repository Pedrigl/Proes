import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public homeText!: string;
  constructor() { }

  ngOnInit(): void {
    this.homeText = 'Welcome to Proes';
  }
}
