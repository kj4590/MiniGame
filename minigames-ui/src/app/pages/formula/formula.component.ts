import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { FormulaService } from '../../services/formula.service';
import { StartFormulaGame } from '../../models/start-formula-game';
import { FormulaAnswerResult } from '../../models/formula-answer-result';

@Component({
  selector: 'app-formula',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './formula.component.html',
  styleUrl: './formula.component.scss'
})
export class FormulaComponent {

  game?: StartFormulaGame;

  expression = '';

  result?: FormulaAnswerResult;

  playerName = '';

  constructor(
    private formulaService: FormulaService,
    private router: Router
  ) { }

  ngOnInit(): void {

    this.playerName =
      localStorage.getItem('playerName') ?? '';

    this.formulaService
      .startGame(this.playerName)
      .subscribe({
        next: data => {
          this.game = data;
        }
      });
  }

  submit(): void {

    this.formulaService
      .submitAnswer({
        playerName: this.playerName,
        expression: this.expression
      })
      .subscribe({
        next: response => {
          this.result = response;
        }
      });
  }

  goMenu(): void {
    this.router.navigate(['/menu']);
  }
}
