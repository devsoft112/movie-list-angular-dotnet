import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';

interface PaginatedMoviesResponse {
  items: any[];
  totalCount: number;
}

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  private apiUrl = `${environment.baseURL}/api/movies`;

  constructor(private http: HttpClient) { }
  
  createMovie(movieData: FormData): Observable<any> {
    return this.http.post<any>(this.apiUrl, movieData);
  }

  getMovies(pageNumber: number = 1, pageSize: number = 10): Observable<PaginatedMoviesResponse> {
    return this.http.get<PaginatedMoviesResponse>(this.apiUrl, {
      params: {
        pageNumber: pageNumber.toString(),
        pageSize: pageSize.toString(),
      },
    });
  }

  getMovieById(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }
  
  updateMovie(id: number, movieData: FormData): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${id}`, movieData);
  }

  deleteMovie(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }
}
