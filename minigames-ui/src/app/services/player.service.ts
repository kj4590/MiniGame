import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreatePlayer } from '../models/create-player';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {

  private apiUrl = 'http://localhost:5099/api/Players';

  constructor(private http: HttpClient) { }

  createPlayer(playerName: string): Observable<any> {
    return this.http.post(this.apiUrl, {playerName});
  }

  getPlayer(playerName: string) {
    return this.http.get(
      `${this.apiUrl}/${playerName}`
    );
  }
}
