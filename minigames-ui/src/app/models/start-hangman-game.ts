export interface StartHangmanGame {
  playerName: string;
  currentWord: string;
  remainingAttempts: number;
  guessedLetters: string[];
}
