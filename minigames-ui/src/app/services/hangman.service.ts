import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { StartHangmanGame } from '../models/start-hangman-game';
import { HangmanAnswerResult } from '../models/hangman-answer-result';
import { SubmitGuess } from '../models/submit-guess';

@Injectable({
  providedIn: 'root'
})
export class HangmanService {

  private apiUrl = 'http://localhost:5099/api/Hangman';

  constructor(private http: HttpClient) { }

  startGame(playerName: string): Observable<StartHangmanGame> {

    return this.http.post<StartHangmanGame>(
      `${this.apiUrl}/start/${playerName}`,
      {}
    );
  }

  submitGuess(
    guess: SubmitGuess
  ): Observable<HangmanAnswerResult> {

    return this.http.post<HangmanAnswerResult>(
      `${this.apiUrl}/guess`,
      guess
    );
  }
}
