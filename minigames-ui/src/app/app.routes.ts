import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { SigninComponent } from './pages/signin/signin.component';
import { CreateAccountComponent } from './pages/create-account/create-account.component';
import { MenuComponent } from './pages/menu/menu.component';
import { FormulaComponent } from './pages/formula/formula.component';
import { HangmanComponent } from './pages/hangman/hangman.component';
import { LeaderboardComponent } from './pages/leaderboard/leaderboard.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'signin', component: SigninComponent },
  { path: 'create-account', component: CreateAccountComponent },
  { path: 'menu', component: MenuComponent },
  { path: 'formula', component: FormulaComponent },
  { path: 'hangman', component: HangmanComponent },
  { path: 'leaderboard', component: LeaderboardComponent },
  { path: '**', redirectTo: '' }
];
