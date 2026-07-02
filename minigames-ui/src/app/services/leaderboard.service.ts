import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Leaderboard } from '../models/leaderboard';

@Injectable({
  providedIn: 'root'
})
export class LeaderboardService {

  private apiUrl =
    'http://localhost:5099/api/Leaderboard';

  constructor(private http: HttpClient) { }

  getLeaderboard() {
    return this.http.get<Leaderboard[]>(this.apiUrl);
  }
}
