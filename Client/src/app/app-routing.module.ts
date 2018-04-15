import { NgModule } from "@angular/core";
import { Routes, RouterModule } from '@angular/router';
import { ListComponent } from "./list/list.component";
import { NotFoundComponent } from "./not-found/not-found.component";
import { ErrorComponent } from "./error/error.component";

const routes: Routes = [
	{
		path: 'error',
		component: ErrorComponent
	},
	{
		path: 'list',
		component: ListComponent
	},
	{
		path: '',
		pathMatch: 'full',
		redirectTo: 'list'
	},
	{
		path: '**',
		component: NotFoundComponent
	}
];

@NgModule({
	imports: [
		RouterModule.forRoot(routes)
	],
	exports: [RouterModule],
	declarations: []
})
export class AppRoutingModule {

}