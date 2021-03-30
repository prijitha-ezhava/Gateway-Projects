import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MultiplyComponent } from './multiply.component';

describe('MultiplyComponent', () => {
  let component: MultiplyComponent;
  let fixture: ComponentFixture<MultiplyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MultiplyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MultiplyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  // it('should create', () => {
  //   expect(component).toBeTruthy();
  // });


  //Positive Test Cases

  it(`should perform Correct Multiplication`, () => {
    //Arrange
    const fixture = TestBed.createComponent(MultiplyComponent);
    //Act
    const app = fixture.componentInstance;
    //Assert
    expect(app.multiplication(10,5)).toEqual(50);
  });
  
  it(`should return zero`, () => {
    //Arrange
    const fixture = TestBed.createComponent(MultiplyComponent);
    //Act
    const app = fixture.componentInstance;
    //Assert
    expect(app.multiplication(10,0)).toEqual(0);
  });

 
  //Negative Test Case
  it(`should perform Incorrect Multiplication`, () => {
    //Arrange
    const fixture = TestBed.createComponent(MultiplyComponent);
    //Act
    const app = fixture.componentInstance;
    //Assert
    expect(app.multiplication(10,5)).toEqual(50);
  });
});
