import { IStudent } from './../models/student.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class StudentsService {
  private apiBaseUrl: string = 'https://localhost:5001/api';

  constructor(private readonly httpClient: HttpClient) {}

  retrieveAllStudents(): Observable<IStudent[]> {
    return this.httpClient.get<IStudent[]>(`${this.apiBaseUrl}/students`);
  }

  retrieveStudentByTheirId(studentId: string): Observable<IStudent> {
    return this.httpClient.get<IStudent>(
      `${this.apiBaseUrl}/students/${studentId}`
    );
  }

  updateStudentDetails(studentToUpdate: IStudent): Observable<IStudent> {
    return this.httpClient.put<IStudent>(
      `${this.apiBaseUrl}/students/${studentToUpdate.id}`,
      studentToUpdate
    );
  }

  deleteStudentByTheirId(studentId: string): Observable<IStudent> {
    return this.httpClient.delete<IStudent>(
      `${this.apiBaseUrl}/students/${studentId}`
    );
  }
}
