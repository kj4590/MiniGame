import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { PlayerService } from '../../services/player.service';

@Component({
  selector: 'app-create-account',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './create-account.component.html',
  styleUrl: './create-account.component.scss'
})
export class CreateAccountComponent {

  playerName: string = '';
  errorMessage: string = '';
  successMessage: string = '';
  loading: boolean = false;

  constructor(
    private playerService: PlayerService,
    private router: Router
  ) { }

  createAccount(): void {

    this.errorMessage = '';
    this.successMessage = '';

    const trimmedPlayerName = this.playerName.trim();

    if (!trimmedPlayerName) {
      this.errorMessage = 'Please enter name.';
      return;
    }

    this.loading = true;

    this.playerService.createPlayer(trimmedPlayerName).subscribe({
      next: () => {
        localStorage.setItem(
          'playerName',
          trimmedPlayerName
        );
        this.successMessage = 'Account successfully created!';
        this.loading = false;
        this.router.navigate(['/menu']);
      },
      error: (error) => {
        this.loading = false;

        if (error.status == 400 || error.status == 400) {
          this.errorMessage = 'Player already exists. Please choose a different name';
        } else {
          this.errorMessage = 'Unable to create account.';
        }
      }
    });
  }

  goToSignIn(): void {
    this.router.navigate(['/signin']);
  }

  goHome(): void {
    this.router.navigate(['/']);
  }
}
