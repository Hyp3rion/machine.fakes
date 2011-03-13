using System.Data;
using System.Data.SqlClient;
using Machine.Fakes.Sdk;
using Machine.Fakes.Specs.TestClasses;
using Machine.Specifications;

namespace Machine.Fakes.Specs
{
    [Subject(typeof(SpecificationController<,>))]
    public class when_using_the_an_method_to_create_an_explicit_fake
    {
        static SpecificationController<object> _specController;
        static object result;
        static DummyFakeEngine _fakeEngine;

        Establish context = () =>
        {
            _fakeEngine = new DummyFakeEngine();
            _fakeEngine.CreatedFake = new SqlConnection();
            _specController = new SpecificationController<object>(_fakeEngine);
        };

        Because of = () => result = _specController.An(typeof(IDbConnection));

        It should_return_a_fake_that_implements_the_specified_type_interface =
            () => result.ShouldBe(typeof(SqlConnection));
    }
}