import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignupComponent } from './components/singup/singup.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'signup' },
  { path: 'signup', component: SignupComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }