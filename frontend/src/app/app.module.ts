import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StoryBrowserComponent } from './components/story-browser/story-browser.component';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { PaginatorComponent } from './components/shared/paginator/paginator.component';

@NgModule({
  declarations: [
    AppComponent,
    StoryBrowserComponent,
    PaginatorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [provideHttpClient(withInterceptorsFromDi(),)],
  bootstrap: [AppComponent]
})
export class AppModule { }
