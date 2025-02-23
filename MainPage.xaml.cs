namespace AnimalMatchingGame
{
    public partial class MainPage : ContentPage
    {
        public MainPage( )
        {
            InitializeComponent();
        }

        private void PlayAgainButton_Clicked( object sender , EventArgs e )
        {
            AnimalButtons.IsVisible = true;
            PlayAgainButton.IsVisible = false;
            TotalMatchesFoundlbl.IsVisible = true;
            TotalMatchesFoundlbl.Text = "Total Matches Found: 0";

            List<string> animalEmoji = [
                "🦝", "🦝",
                "🐢", "🐢",
                "🐻", "🐻",
                "🐰", "🐰",
                "🦊", "🦊",
                "🐺", "🐺",
                "🐌", "🐌",
                "🦚", "🦚"
                ];

            foreach ( var button in AnimalButtons.Children.OfType<Button>() )
            {
                int index = Random.Shared.Next( animalEmoji.Count );
                string nextEmoji = animalEmoji [ index ];
                button.Text = nextEmoji;
                animalEmoji.RemoveAt( index );
            }
        }

        Button lastClicked;
        bool findingMatch = false;
        int matchesFound;

        private void Button_Clicked( object sender , EventArgs e )
        {
            // If the event sent is a Button being clicked do the following...
            if ( sender is Button buttonClicked )
            {
                // If the string is not empty or just has white space & its the first card clicked in
                // the set do the following
                if ( !string.IsNullOrWhiteSpace( buttonClicked.Text ) && ( findingMatch == false ) )
                {
                    // Changes card clicked to Red
                    buttonClicked.BackgroundColor = Colors.Red;
                    // Makes card just clicked = to 'lastClicked'
                    lastClicked = buttonClicked;
                    // Changes it to trying to find a match instead of the 1st card in a pair
                    findingMatch = true;
                } else
                {
                    // If the btnClicked is not the card just clicked & btns txt/emoji is = to first card
                    // & the cards text is not 'Null' or 'WhiteSpace' do the following...
                    if ( ( buttonClicked != lastClicked ) && ( buttonClicked.Text == lastClicked.Text )
                        && ( !string.IsNullOrWhiteSpace( buttonClicked.Text ) ) )
                    {
                        // Add one to 'matchesFound' count
                        matchesFound++;
                        // Adds one to total cound of MatchesFoundlbl Text
                        TotalMatchesFoundlbl.Text = $"Total Matches Found: {matchesFound}";
                        // Change last btn clicked from its emoji to whitespace
                        lastClicked.Text = " ";
                        // Change btn just clicked from its emoji to whitespace
                        buttonClicked.Text = " ";
                    }
                    // Change the 2 cards clicked back to light blue
                    lastClicked.BackgroundColor = Colors.LightBlue;
                    buttonClicked.BackgroundColor = Colors.LightBlue;
                    // Switch back 'findingMatch' to false to start looking for new pair
                    findingMatch = false;
                }
            }
            // If 'matchesFound' = 8 (game completed 8 out of 8)
            // *may change to list length so it can change if more buttons are added over 16*
            if ( matchesFound == 8 )
            {
                // 'matchesFound' back to 0 from 8
                matchesFound = 0;
                // Changes 'TotalMatchesFoundlbl' back to 0
                TotalMatchesFoundlbl.Text = string.Empty;
                // Change 'AnimalButtons' back to not visible
                AnimalButtons.IsVisible = false;
                // Change 'PlayAgainButton' to visible so it can be clicked to restart a new match
                PlayAgainButton.IsVisible = true;
                // Change 'TotalMatchesFoundlbl' back to not visible
                TotalMatchesFoundlbl.IsVisible = false;
            }

        }
    }

}
