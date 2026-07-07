import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { HangmanService } from '../../services/hangman.service';
import { StartHangmanGame } from '../../models/start-hangman-game';
import { HangmanAnswerResult } from '../../models/hangman-answer-result';

@Component({
  selector: 'app-hangman',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './hangman.component.html',
  styleUrl: './hangman.component.scss'
})
export class HangmanComponent {

  playerName = '';

  game?: StartHangmanGame;

  result?: HangmanAnswerResult;

  letter = '';

  constructor(
    private hangmanService: HangmanService,
    private router: Router
  ) { }

  ngOnInit(): void {

    this.playerName =
      localStorage.getItem('playerName') ?? '';

    this.hangmanService
      .startGame(this.playerName)
      .subscribe({
        next: (data: StartHangmanGame) => {
          this.game = data;
        }
      });
  }

  submitGuess(): void {

    if (!this.letter.trim()) {
      return;
    }

    this.hangmanService
      .submitGuess({
        playerName: this.playerName,
        letter: this.letter.charAt(0)
      })
      .subscribe({
        next: (response: HangmanAnswerResult) => {

          this.result = response;

          this.letter = '';
        }
      });
  }

  goBack(): void {
    this.router.navigate(['/menu']);
  }
}
