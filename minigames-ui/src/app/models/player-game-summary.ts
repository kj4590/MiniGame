
import { FormulaGameResult } from './formula-game-result';
import { HangmanGameResult } from './hangman-game-result';

export interface PlayerGameSummary {
  playerId: number;
  playerName: string;
  formulaGameResult: FormulaGameResult;
  hangmanGameResult: HangmanGameResult;
}
