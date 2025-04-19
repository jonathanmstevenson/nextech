import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StoryBrowserComponent } from './components/story-browser/story-browser.component';

const routes: Routes = [
  { path: '**', redirectTo: 'stories' },
  { path: 'stories', component: StoryBrowserComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
