import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface PaginatedMoviesResponse {
  items: any[];
  totalCount: number;
}

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  private apiUrl = 'http://localhost:5103/api/movies';  // Adjust the base URL as necessary

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
