import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { StartFormulaGame } from '../models/start-formula-game';
import { FormulaAnswerResult } from '../models/formula-answer-result';
import { SubmitFormulaAnswer } from '../models/submit-formula-answer';

@Injectable({
  providedIn: 'root'
})
export class FormulaService {

  private apiUrl = 'http://localhost:5099/api/Formula';

  constructor(private http: HttpClient) { }

  startGame(
    playerName: string
  ): Observable<StartFormulaGame> {

    return this.http.get<StartFormulaGame>(
      `${this.apiUrl}/start/${playerName}`
    );
  }

  submitAnswer(answer: SubmitFormulaAnswer): Observable < FormulaAnswerResult > {
    return this.http.post<FormulaAnswerResult>(
      `${this.apiUrl}/submit`,
      answer
    );
  }
}
