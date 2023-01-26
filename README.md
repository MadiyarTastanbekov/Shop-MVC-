# Shop-MVC-
Used from this source:https://www.youtube.com/watch?v=_glP2S7gygA&amp;list=PL0lO_mIqDDFWltIe7D6aUS5f4k1y2-rgn&amp;index=5
beforeEach(() => {

  //cy.visit('http://localhost:3000/apps/deep-cypress.html');
  cy.visit('https://localhost:44377/');
});

it.only('Should click download button', () => {
  // cy.window().then((window)=>{
  //     cy.stub(window,'open').callsFake((url)=>{
  //         alert('OK Window')
  //         window.location=url;

  //     })
  // });
  // cy.window().document().then(function (doc) {
  //     doc.addEventListener('click', () => {
  //       setTimeout(function () { doc.location.reload() }, 5000)
  //     })
  //     cy.get('.GenetareFile').click().as('waiters')

  //   })
  cy.window().document().then(function (doc) {
    doc.addEventListener('click', () => {
      setTimeout(function () { doc.location.reload() }, 5000)
    })
    /* Make sure the file exists */
    cy.intercept('/', (req) => {
      req.reply((res) => {
        expect(res.statusCode).to.equal(200);
      });
    });
    cy.get('.GenetareFile').click()
  })
  cy.wait(1000)
  cy.get('.nav > :nth-child(3) > a').click()
  cy.get('[href="/Cars/EditPost/1"]').click();
  cy.get('body > :nth-child(3) > a').click({force:true});
});
it('should do long like', () => {
  cy.get('section[data-cy=long-like]').as('section');
  cy.get('@section').find('button').click();
  cy.get('@section').find('[data-cy=success]')
    .should('have.text', 'Well done!');
});
it('should do find child in tree', () => {
  cy.get('section[data-cy=child-in-tree]').as('section');
  cy.get('@section').find('button').click();
  //  cy.get('@section').find('[data-cy=daddy] [data-cy=child]').should('be.visible');
  cy.get('@section').find('[data-cy=daddy]').should('not.contain', 'Loading')
    .find('[data-cy=child]').should('be.visible');

});

