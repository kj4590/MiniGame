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

  playerName = '';

  constructor(
    private playerService: PlayerService,
    private router: Router
  ) { }

  createAccount(): void {

    if (!this.playerName.trim()) {
      return;
    }

    this.playerService.createPlayer({
      playerName: this.playerName
    }).subscribe({
      next: () => {
        localStorage.setItem(
          'playerName',
          this.playerName
        );

        this.router.navigate(['/menu']);
      }
    });
  }
}
