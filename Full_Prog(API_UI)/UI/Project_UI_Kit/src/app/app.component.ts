import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RegFormComponent } from "./Core/Component/reg-form/reg-form.component";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [RouterOutlet, RegFormComponent]
})
export class AppComponent {
  title = 'Project_UI_Kit';
}
