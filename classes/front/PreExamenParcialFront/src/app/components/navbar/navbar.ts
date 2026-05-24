import { Component, HostListener, Input } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './navbar.html',
  styleUrl: './navbar.css',
})
export class NavbarComponent {
  @Input() transparent = false;
  @Input() showHomeLinks = false;

  isMenuOpen = false;
  isScrolled = false;

  @HostListener('window:scroll')
  onScroll() {
    if (typeof window !== 'undefined') {
      this.isScrolled = window.scrollY > 60;
    }
  }

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }

  closeMenu() {
    this.isMenuOpen = false;
  }
}
