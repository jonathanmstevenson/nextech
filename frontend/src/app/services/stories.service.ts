import { Injectable } from '@angular/core';
import { ApiBaseService } from './api-base.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IStory } from '../models/interfaces/story.interface';
import { IPaginated } from '../models/interfaces/paginator.interface';

@Injectable({
  providedIn: 'root'
})
export class StoriesService extends ApiBaseService {

  private route: string = this.Origin + '/stories';

  constructor(private _http: HttpClient) {
    super();
  }


  getLatest(pgSize: number, pgNumber: number, term?: string): Observable<IPaginated<IStory>> {
    var query = this.route + `?pgSize=${pgSize}&pgNumber=${pgNumber}`;
    query += term ? `&term=${term}` : '';
    return this._http.get<IPaginated<IStory>>(query);
  }
}
