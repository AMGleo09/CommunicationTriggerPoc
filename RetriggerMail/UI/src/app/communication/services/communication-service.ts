import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CommunicationLog } from '../models/communication-log.model';

@Injectable({
  providedIn: 'root',
})
export class CommunicationService {

  private baseUrl = 'https://localhost:7052/api/communication';

  constructor(private http: HttpClient) {}

  getLogs(claimNumber: string): Observable<CommunicationLog[]> {
    return this.http.get<CommunicationLog[]>(`${this.baseUrl}/${claimNumber}`);
  }

  retrigger(logId: number): Observable<any> {
    return this.http.post(`${this.baseUrl}/retrigger/${logId}`, {});
  }
}
