import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { PlayerService } from '../../services/player.service';

@Component({
  selector: 'app-signin',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './signin.component.html',
  styleUrl: './signin.component.scss'
})
export class SigninComponent {

  playerName = '';
  errorMessage = '';
  loading = false;

  constructor(
    private playerService: PlayerService,
    private router: Router
  ) { }

  signIn(): void {

    this.errorMessage = '';

    const trimmedPlayerName = this.playerName.trim();

    if (!trimmedPlayerName) {
      this.errorMessage = 'Please enter a player name.';
      return;
    }

    this.loading = true;

    this.playerService
      .getPlayer(trimmedPlayerName)
      .subscribe({
        next: () => {

          localStorage.setItem(
            'playerName',
            trimmedPlayerName
          );

          this.loading = false;
          this.router.navigate(['/menu']);
        },

        error: () => {

          this.loading = false;

          this.errorMessage =
            'Player not found. Please create an account.';
        }
      });
  }

  goToCreateAccount(): void {
    this.router.navigate(['/create-account']);
  }

  goHome(): void {
    this.router.navigate(['/']);
  }
}
