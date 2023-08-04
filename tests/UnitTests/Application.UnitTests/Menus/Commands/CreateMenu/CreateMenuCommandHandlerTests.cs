using Application.Common.Interfaces.Persistence;
using Application.Menus.Commands.CreateMenu;
using Application.UnitTests.Menus.Commands.TestUtils;
using Application.UnitTests.TestUtils.Menus.Extensions;
using FluentAssertions;
using Moq;

namespace Application.UnitTests.Menus.Commands.CreateMenu;

/// <summary>
/// SUT - System Under Test
/// </summary>
public class CreateMenuCommandHandlerTests
{
    private readonly CreateMenuCommandHandler _handler;
    private readonly Mock<IMenuRepository> _menuRepositoryMock;

    public CreateMenuCommandHandlerTests()
    {
        _menuRepositoryMock = new Mock<IMenuRepository>();
        _handler = new CreateMenuCommandHandler(_menuRepositoryMock.Object);
    }

    // T1 SUT - logical component we are testing
    // T2 Scenario - what we are testing
    // T3 Expected Result - what we expect for logical component to do
    [Theory]
    [MemberData(nameof(ValidCreateMenuCommands))]
    public async Task HandleCreateMenuCommmand_WHenMenuIsValid_SHouldCreateAndReturnMenu(CreateMenuCommand createMenuCommand)
    {
        // Act
        var result = await _handler.Handle(createMenuCommand, default);

        // Assert
        result.IsError.Should().BeFalse();

        result.Value.ValidateCreatedFrom(createMenuCommand);
        _menuRepositoryMock.Verify(m => m.AddAsync(result.Value), Times.Once);
    }

    public static IEnumerable<object[]> ValidCreateMenuCommands()
    {
        // Arrange
        // Get hold of a valid menu

        yield return new[] { CreateMenuCommandUtils.CreateCommand() };
        yield return new[] {CreateMenuCommandUtils.CreateCommand(
            sections:CreateMenuCommandUtils.CreateSectionsCommand(sectionCount: 3))
        };
        yield return new[] {CreateMenuCommandUtils.CreateCommand(
            sections:CreateMenuCommandUtils.CreateSectionsCommand(
                sectionCount: 3,
                items:CreateMenuCommandUtils.CreateMenuItemsCommand(itemCount: 3)
            ))
        };

    }
}
