import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.scss'
})
export class MenuComponent {

  playerName = '';

  constructor(private router: Router) { }

  ngOnInit(): void {

    this.playerName =
      localStorage.getItem('playerName') ?? '';

    if (!this.playerName) {
      this.router.navigate(['/']);
    }
  }

  goToFormula(): void {
    this.router.navigate(['/formula']);
  }

  goToHangman(): void {
    this.router.navigate(['/hangman']);
  }

  goToLeaderboard(): void {
    this.router.navigate(['/leaderboard']);
  }

  goHome(): void {
    this.router.navigate(['/']);
  }

  signOut(): void {

    localStorage.removeItem('playerName');

    this.router.navigate(['/']);
  }
}
