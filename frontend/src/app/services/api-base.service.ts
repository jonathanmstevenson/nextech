import { Injectable, isDevMode } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiBaseService {

  private _origin!: string;

  constructor() {
    this._origin = isDevMode() ? 'http://localhost:5006/api' : '$(api_baseurl)';
  }

  get Origin(): Readonly<string> {
    return this._origin;
  }
}
