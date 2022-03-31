import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IGender } from '../models/gender.model';

@Injectable({
  providedIn: 'root',
})
export class GendersService {
  private apiBaseUrl: string = 'https://localhost:5001/api';

  constructor
  (
     private readonly httpclient: HttpClient
  ) {}

  retrieveAll(): Observable<IGender[]> {
    return this.httpclient.get<IGender[]>(`${this.apiBaseUrl}/genders`);
  }
}
