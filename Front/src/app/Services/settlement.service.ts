import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Settlement } from '../Models/settlement.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class SettlementService {
  constructor(private http: HttpClient) {}
  private apiUrl = `https://localhost:7141/Settlement`;
  
  GetAll(): Observable<Settlement[]> {
    return this.http.get<Settlement[]>(`${this.apiUrl}`);
  }
 
  new:Settlement = {settlementId: 0, settlementName: ''};
  AddNewSettlement(newSettlement: string): Observable<Settlement> {
    this.new.settlementName=newSettlement;
    return this.http.post<Settlement>(`${this.apiUrl}`, this.new);
  }

  EditSettlement(editSettlement: Settlement): Observable<boolean> {
    console.log(editSettlement);
    
    return this.http.put<boolean>(`${this.apiUrl}`, editSettlement);
  }

  DeleteSettlement(settlement: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}?id=${settlement}`);
  }
}
