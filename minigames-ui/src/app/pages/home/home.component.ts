import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LeaderboardService } from '../../services/leaderboard.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {

  leaderboard: any[] = [];

  constructor(private router: Router, private leaderboardService: LeaderboardService) { }

  ngOnInit(): void {

    this.leaderboardService
      .getLeaderboard()
      .subscribe({
        next: data => {
          this.leaderboard = data;
        }
      });

    const playerName = localStorage.getItem('playerName');

    if (playerName) {
      this.router.navigate(['/menu']);
    }
  }

  signIn(): void {
    this.router.navigate(['/signin']);
  }

  createAccount(): void {
    this.router.navigate(['/create-account']);
  }
}
