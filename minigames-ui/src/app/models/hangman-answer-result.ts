export interface HangmanAnswerResult {
  currentWord: string;
  remainingAttempts: number;
  guessedLetters: string[];
  message: string;
  isWon: boolean;
  isGameOver: boolean;
}
