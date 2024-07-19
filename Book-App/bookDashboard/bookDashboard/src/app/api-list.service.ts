import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiListService {
  private baseUrl = 'https://www.googleapis.com/books/v1/volumes?q=recommendations';
  private apiUrl = 'http://openlibrary.org/search.json';
  private loginUrl = 'http://localhost:5255/api/Authentication/login';
  private BooksUrl = 'http://localhost:5075/api/book';
  private registerUrl = 'http://localhost:5255/api/Authentication/register';
  private authorsUrl = 'http://localhost:5207/api/authors';
  
  constructor(private http: HttpClient) { }

  // getPopularBooks(): Observable<any> {
  //   return this.http.get(`${this.baseUrl}/search.json?q=popular`);
  // }

  getCoverImageUrl(coverId: number): string {
    return `https://covers.openlibrary.org/b/id/${coverId}-L.jpg`;
  }

  getRecommendations(subject: string, limit: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/subjects/${subject}.json?limit=${limit}`);
  }

  searchBooks(query: string): Observable<any> {
    return this.http.get(`${this.apiUrl}?q=${query}`);
  }

  login(username: string, password: string): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const body = { username, password };

    return this.http.post<any>(this.loginUrl, body, { headers });
  }

  getPopularBooks(): Observable<any> {
    return this.http.get<any>(this.BooksUrl);
  }

  register(user: any): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<any>(this.registerUrl, user, { headers });
  }

  getAuthors(): Observable<any[]> {
    return this.http.get<any[]>(this.authorsUrl);
  }

}
