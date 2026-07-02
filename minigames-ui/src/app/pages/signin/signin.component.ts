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

  constructor(
    private playerService: PlayerService,
    private router: Router
  ) { }

  signIn(): void {

    if (!this.playerName.trim()) {
      return;
    }

    this.playerService
      .getPlayer(this.playerName)
      .subscribe({
        next: (player) => {

          localStorage.setItem(
            'playerName',
            this.playerName
          );

          this.router.navigate(['/menu']);
        },

        error: () => {

          this.playerService
            .createPlayer({
              playerName: this.playerName
            })
            .subscribe({
              next: () => {

                localStorage.setItem(
                  'playerName',
                  this.playerName
                );

                this.router.navigate(['/menu']);
              },

              error: () => {
                alert('Unable to create player.');
              }
            });
        }
      });
  }

  goHome(): void {
    this.router.navigate(['/']);
  }
}
